using BookStore.ViewModal;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Interface
{
    public interface IBookInv
    {

        public (JsonResult result, bool succeeded) BookInvList();
        public (JsonResult result, bool succeeded) DeleteInvList(int id);
        public (JsonResult result, bool succeeded) GetBookInvList(int id);
        public (JsonResult result, bool succeeded) UpdateBookInvList(BookData book);
        public (JsonResult result, bool succeeded) AddNewBookDataList(BookData book);
    }
}
