using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Result
    {
        private string _Desc;
        public Result(bool state)
        {
            State = state;
        }
        public bool State { get; set; }
        public string ResultDesc
        {
            get
            {
                if (string.IsNullOrEmpty(_Desc))
                {
                    if (State)
                        return "عملیات با موفقیت انجام شد";
                    else
                        return "عملیات با خطا مواجه شده است.";
                }
                else
                {
                    return _Desc;
                }
            }
            set { _Desc = value; }
        }
        public long Id { get; set; }
    }
}
