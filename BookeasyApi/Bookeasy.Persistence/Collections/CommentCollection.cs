using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Data.Services;
using Bookeasy.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookeasy.Persistence.Collections
{
    public class CommentCollection : CollectionBase<Post>, ICommentCollection
    {
        private readonly IMongoCollection<Post> _posts;

        public CommentCollection(IMongoCollection<Post> collection) : base(collection)
        {
            _posts = collection;
        }

        public List<Comment> GetByPostId(string postId)
        {
            var post = _posts.Find(post => post.Id.ToString() == postId).FirstOrDefault();
            if (post != null)
                return post.Comments;
            throw new InvalidOperationException("Post not found");
        }

        public Comment Get(string id)
        {
            var post = _posts.Find(post => post.Comments.Any(i => i.Id.ToString() == id)).FirstOrDefault();
            if (post != null)
                return post.Comments.First(i => i.Id.ToString() == id);
            throw new InvalidOperationException("Comment not found under commentId");
        }

        public Comment Add(string postId, Comment comment)
        {
            var update = Builders<Post>.Update.Push(post => post.Comments, comment);
            var post = _posts.FindOneAndUpdate(post => post.Id.ToString() == postId, update);
            return null;
        }

        public async Task<Comment> AddAsync(string postId, Comment comment)
        {
            comment.Id = ObjectId.GenerateNewId();
            var update = Builders<Post>.Update.Push(p => p.Comments, comment);
            var post = await _posts.FindOneAndUpdateAsync<Post>(
                post1 => post1.Id.CompareTo(ObjectId.Parse(postId)) == 0, update, new FindOneAndUpdateOptions<Post>()
                {
                    ReturnDocument = ReturnDocument.After,
                    IsUpsert = false
                });

            var newComment = post.Comments.OrderBy(i => i.CreationDate).Last();

            return newComment;
        }

        public Comment Update(string commentId, Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Comment> UpdateAsync(string postId, Comment comment)
        {
            var filter = Builders<Post>.Filter.Eq(post => post.Id, ObjectId.Parse(postId))
                         & Builders<Post>.Filter.ElemMatch(post => post.Comments,
                             Builders<Comment>.Filter.Eq(c => c.Id, comment.Id)
                             & Builders<Comment>.Filter.Eq(c => c.OwnerUserId, comment.OwnerUserId));
            var update = Builders<Post>.Update.Set(post => post.Comments[-1].Body, comment.Body);
            var post = await _posts.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Post>
            {
                ReturnDocument = ReturnDocument.After
            });
            var updatedComment = post.Comments.SingleOrDefault(i => i.Id == comment.Id);
            return updatedComment;
        }

        public void Remove(string postId, string commentId)
        {
            var updateDefinition = Builders<Post>.Update.PullFilter(post => post.Comments,
                comment => comment.Id == ObjectId.Parse(commentId));
            _posts.FindOneAndUpdate(post => post.Id == ObjectId.Parse(postId), updateDefinition);
        }

        public async Task RemoveAsync(string postId, string commentId)
        {
            var updateDefinition = Builders<Post>.Update.PullFilter(post => post.Comments,
                comment => comment.Id == ObjectId.Parse(commentId));
            await _posts.FindOneAndUpdateAsync(post => post.Id == ObjectId.Parse(postId), updateDefinition);
        }

        public async Task CreateUpVoteAsync(string postId, string commentId, string userId)
        {
            var filter = Builders<Post>.Filter.And(Builders<Post>.Filter.Eq(post => post.Id, ObjectId.Parse(postId)),
                Builders<Post>.Filter.ElemMatch(x => x.Comments, comment => comment.Id == ObjectId.Parse(commentId)));
            var updateDefinition = Builders<Post>.Update
                .AddToSet(post => post.Comments[-1].UserVotedUp, userId)
                .Pull(post => post.Comments[-1].UserVotedDown, userId);
            await _posts.FindOneAndUpdateAsync(filter, updateDefinition);
        }

        public async Task CreateDownVoteAsync(string postId, string commentId, string userId)
        {
            var filter = Builders<Post>.Filter.And(Builders<Post>.Filter.Eq(post => post.Id, ObjectId.Parse(postId)),
                Builders<Post>.Filter.ElemMatch(x => x.Comments, comment => comment.Id == ObjectId.Parse(commentId)));
            var updateDefinition = Builders<Post>.Update
                .AddToSet(post => post.Comments[-1].UserVotedDown, userId)
                .Pull(post => post.Comments[-1].UserVotedUp, userId);
            await _posts.FindOneAndUpdateAsync(filter, updateDefinition);
        }

        public async Task RemoveVoteAsync(string postId, string commentId, string userId)
        {
            var filter = Builders<Post>.Filter.And(Builders<Post>.Filter.Eq(post => post.Id, ObjectId.Parse(postId)),
                Builders<Post>.Filter.ElemMatch(x => x.Comments, comment => comment.Id == ObjectId.Parse(commentId)));
            var updateDefinition = Builders<Post>.Update
                .Pull(post => post.Comments[-1].UserVotedDown, userId)
                .Pull(post => post.Comments[-1].UserVotedUp, userId);
            await _posts.FindOneAndUpdateAsync(filter, updateDefinition);
        }
    }
}