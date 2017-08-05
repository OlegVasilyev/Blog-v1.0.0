using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviews();
        void CreateReview(ReviewDTO reviewDto);
        void DeleteReview(int? Id);
    }
}
