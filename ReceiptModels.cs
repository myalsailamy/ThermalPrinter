using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ThermalReceiptPrinter
{
    public class ReceiptItem
    {
        /// <summary>اسم الصنف بالعربية.</summary>
        public string NameAr { get; set; }

        /// <summary>اسم الصنف بالإنجليزية (اختياري - يُطبع كسطر ثانٍ أسفل الاسم العربي).</summary>
        public string NameEn { get; set; }

        public decimal Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Math.Round(Quantity * UnitPrice, 2);
    }

    /// <summary>يمثل كل بيانات فاتورة المبيعات الضريبية المطلوب طباعتها (ثنائية اللغة).</summary>
    public class ReceiptModel
    {
        // ---------- بيانات الشركة ----------
        public string CompanyNameAr { get; set; }
        public string CompanyNameEn { get; set; }
        public string TaxNumber { get; set; }
        public string CommercialRegister { get; set; }

        /// <summary>افتراضيًا "فاتورة ضريبية" - غيّرها لو أردت عنوانًا آخر.</summary>
        public string InvoiceTitleAr { get; set; } = "فاتورة ضريبية";

        /// <summary>افتراضيًا "TAX INVOICE".</summary>
        public string InvoiceTitleEn { get; set; } = "TAX INVOICE";

        // ---------- بيانات الفاتورة ----------
        public string InvoiceNumber { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string CashierName { get; set; }
        public string CustomerName { get; set; } = "نقداً";

        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();

        public decimal Discount { get; set; } = 0;

        /// <summary>ضريبة القيمة المضافة.</summary>
        public decimal VatAmount { get; set; } = 0;

        public int ItemCount => Items.Count;
        public decimal TotalQuantity => Items.Sum(i => i.Quantity);
        public decimal SubtotalBeforeVat => Math.Round(Items.Sum(i => i.LineTotal) - Discount, 2);
        public decimal GrandTotal => Math.Round(SubtotalBeforeVat + VatAmount, 2);

        /// <summary>رمز العملة يُطبع بجانب الإجمالي النهائي، مثل "ر.س".</summary>
        public string CurrencySymbol { get; set; } = "ر.س";

        // ---------- تذييل الفاتورة ----------
        public string FooterThanksAr { get; set; } = "شكراً لتسوقكم معنا";
        public string FooterThanksEn { get; set; } = "Thank You For Shopping With Us";

        public string ReturnPolicyAr { get; set; }
        public string ReturnPolicyEn { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        /// <summary>مثال: "Facebook | Instagram | X"</summary>
        public string SocialMediaLine { get; set; }

        public string FarewellAr { get; set; } = "نتمنى لكم يوماً سعيداً";
        public string FarewellEn { get; set; } = "Visit Us Again";

        /// <summary>شعار اختياري يُطبع أعلى الفاتورة.</summary>
        public Image Logo { get; set; }
    }
}
