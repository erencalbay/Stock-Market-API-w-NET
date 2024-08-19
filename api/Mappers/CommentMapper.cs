using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Dtos.DTOComment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                StockId = commentModel.StockId,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommandDto commandDto, int stockId)
        {
            return new Comment
            {
                Title = commandDto.Title,
                StockId = stockId,
                Content = commandDto.Content,
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commandDto)
        {
            return new Comment
            {
                Title = commandDto.Title,
                Content = commandDto.Content,
            };
        }
    }
}