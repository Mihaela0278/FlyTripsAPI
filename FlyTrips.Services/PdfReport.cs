using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlyTrips.Services
{
    public class PdfReport : IPdfReport
    {
        private readonly IConverter _converter;
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;
        private readonly IAirlineService _airlineService;
        private readonly IRoleService _roleService;

        public PdfReport(IRoleService roleService,
                        IAirlineService airlineService,
                        ITicketService ticketService,
                        IUserService userService,
                        IConverter converter)
        {
            _roleService = roleService;
            _airlineService = airlineService;
            _ticketService = ticketService;
            _userService = userService;
            _converter = converter;
        }

        public void ExportPdf()
        {
            GlobalSettings globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = "PdfReport.pdf"
            };

            ObjectSettings objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetPdfContent(),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial" },
                FooterSettings = { FontName = "Arial" }
            };

            HtmlToPdfDocument pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);
        }

        private string GetPdfContent()
        {
            return

$@"<html>
    <head>
        <style>
            .header {{
                text-align: center;
                color: green;
                padding-bottom: 35px;
            }}

            table {{
                width: 80%;
                border-collapse: collapse;
                margin: 0 auto;
            }}

            td, th {{
                border: 1px solid gray;
                padding: 15px;
                font-size: 22px;
                text-align: center;
            }}

            table th {{
                background-color: green;
                color: white;
            }}
        </style>
    </head>
    <body>
        <div class='header'>
            <h1>PDF Report</h1>
        </div>
        <table>
            <thead>
                <th>Entity Name</th>
                <th>Count</th>
            </thead>
            <tr>
                <td>Users</td>
                <td>{_userService.GetCount()}</td>
            </tr>
            <tr>
                <td>Tickets</td>
                <td>{_ticketService.GetCount()}</td>
            </tr>
            <tr>
                <td>Airlines</td>
                <td>{_airlineService.GetCount()}</td>
            </tr>
            <tr>
                <td>Roles</td>
                <td>{_roleService.GetCount()}</td>
            </tr>
        </table>
    </body>
</html>";

        }
    }
}
