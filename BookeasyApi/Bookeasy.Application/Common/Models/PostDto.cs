using System;
using System.Collections.Generic;
using AutoMapper;
using Bookeasy.Application.Common.Mappings;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Common.Models
{
    public class PostDto : IMapFrom<Post>
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeletionDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime LastActivityDate { get; set; } = DateTime.Now;
        public DateTime? ClosedDate { get; set; }
        public List<Comment> Comments { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostDto, Post>();
            profile.CreateMap<Post, PostDto>()
                .ForMember(dest => dest.UpVote, options => options.MapFrom(src => src.UsersVotedUp.Count))
                .ForMember(dest => dest.DownVote, options => options.MapFrom(src => src.UsersVotedDown.Count));
        }
    }
}