using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum ExpenseType
    {

        [Display(Name = "Fatura")]
        Invoice = 1,
        [Display(Name = "Teknik Gider")]
        TechnicalExpense = 2,
        [Display(Name = "Maaş Ödemesi")]
        SalaryPayment = 3,
        [Display(Name = "Diğer Gider")]
        OtherExpense = 4
    }
}
