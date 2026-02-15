using Application.Dtos.Coach_Dto;
using Application.Dtos.PerformanceNote;
using Application.Dtos.PerformanceRecord;
using Application.Dtos.Swimmer_Dto;
using Application.Dtos.TeamDto;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PerformanceNoteDto = Application.Dtos.PerformanceNote.PerformanceNoteDto;

namespace Application
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {

            // Coach Mappings


            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level))
                .ForMember(dest => dest.TeamCount, opt => opt.MapFrom(src => src.Teams));


            // Swimmer Mappings


            CreateMap<Swimmer, SwimmerDto>()
                .ForMember(dest => dest.CompetitionReadinessName, opt => opt.MapFrom(src => src.CompetitionReadiness.ToString()))
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.Name : null));


            // Team Mappings


            CreateMap<Team, TeamDto>()
               .ForMember(dest => dest.CoachName, opt => opt.MapFrom(src => src.Coach.FullName))
               .ForMember(dest => dest.SwimmerCount, opt => opt.MapFrom(src => src.Swimmers.Count));

            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();

            // PerformanceRecord mappings


            CreateMap<PerformanceRecord, PerformanceRecordDto>()
             .ForMember(dest => dest.SwimmerName, opt => opt.MapFrom(src => src.Swimmer.FullName))
             .ForMember(dest => dest.RecordedByCoachName, opt => opt.MapFrom(src => src.RecordedByCoach.FullName));
             CreateMap<CreatePerformanceRecordDto, PerformanceRecord>();
             CreateMap<UpdatePerformanceRecordDto, PerformanceRecord>();

            // PerformanceNote mappings


            CreateMap<PerformanceNote, PerformanceNoteDto>()
                .ForMember(dest => dest.SwimmerName, opt => opt.MapFrom(src => src.Swimmer.FullName))
                .ForMember(dest => dest.CoachName, opt => opt.MapFrom(src => src.Coach.FullName));
            CreateMap<CreatePerformanceNoteDto, PerformanceNote>();

            // Dashboard mappings


            CreateMap<PerformanceRecord, RecentPerformanceDto>()
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => (int)src.Distance))
                .ForMember(dest => dest.RecordedByCoachName, opt => opt.MapFrom(src => src.RecordedByCoach.FullName));

            CreateMap<PerformanceRecord, PerformanceRecordSimpleDto>();

            CreateMap<PerformanceNote, PerformanceNoteDto>()
                .ForMember(dest => dest.SwimmerName, opt => opt.MapFrom(src => src.Swimmer.FullName))
                .ForMember(dest => dest.CoachName, opt => opt.MapFrom(src => src.Coach.FullName));


        }
    }
}
