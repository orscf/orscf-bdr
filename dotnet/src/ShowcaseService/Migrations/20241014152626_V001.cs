using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalResearch.BillingData.Migrations
{
    /// <inheritdoc />
    public partial class V001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BdrStudyExecutionScopes",
                columns: table => new
                {
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutingInstituteIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteRelatedTaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SiteRelatedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrStudyExecutionScopes", x => x.StudyExecutionIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "BdrBillableVisits",
                columns: table => new
                {
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisitProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueExecutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillableVisits", x => x.VisitGuid);
                    table.ForeignKey(
                        name: "FK_BdrBillableVisits_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrBillingDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransmissionDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillingDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdrBillingDemands_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OffcialInvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransmissionDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentSubmittedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentReceivedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorrectionOfInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdrInvoices_BdrInvoices_CorrectionOfInvoiceId",
                        column: x => x.CorrectionOfInvoiceId,
                        principalTable: "BdrInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrInvoices_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrVisitBillingRecords",
                columns: table => new
                {
                    BillingRecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FixedExecutionState = table.Column<int>(type: "int", nullable: false),
                    FixedPriceOfVisit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedPriceOfTasks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedTaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasksRelatedInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrVisitBillingRecords", x => x.BillingRecordId);
                    table.ForeignKey(
                        name: "FK_BdrVisitBillingRecords_BdrBillableVisits_VisitGuid",
                        column: x => x.VisitGuid,
                        principalTable: "BdrBillableVisits",
                        principalColumn: "VisitGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrVisitBillingRecords_BdrBillingDemands_BillingDemandId",
                        column: x => x.BillingDemandId,
                        principalTable: "BdrBillingDemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrVisitBillingRecords_BdrInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "BdrInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableVisits_StudyExecutionIdentifier",
                table: "BdrBillableVisits",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillingDemands_StudyExecutionIdentifier",
                table: "BdrBillingDemands",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrInvoices_CorrectionOfInvoiceId",
                table: "BdrInvoices",
                column: "CorrectionOfInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrInvoices_StudyExecutionIdentifier",
                table: "BdrInvoices",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrVisitBillingRecords_BillingDemandId",
                table: "BdrVisitBillingRecords",
                column: "BillingDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrVisitBillingRecords_InvoiceId",
                table: "BdrVisitBillingRecords",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrVisitBillingRecords_VisitGuid",
                table: "BdrVisitBillingRecords",
                column: "VisitGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdrVisitBillingRecords");

            migrationBuilder.DropTable(
                name: "BdrBillableVisits");

            migrationBuilder.DropTable(
                name: "BdrBillingDemands");

            migrationBuilder.DropTable(
                name: "BdrInvoices");

            migrationBuilder.DropTable(
                name: "BdrStudyExecutionScopes");
        }
    }
}
