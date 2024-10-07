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
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrStudyExecutionScopes", x => x.StudyExecutionIdentifier);
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
                    PaymentReceivedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdrInvoices_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrBillableVisits",
                columns: table => new
                {
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisitProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExecutionEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SponsorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillableVisits", x => x.VisitGuid);
                    table.ForeignKey(
                        name: "FK_BdrBillableVisits_BdrBillingDemands_BillingDemandId",
                        column: x => x.BillingDemandId,
                        principalTable: "BdrBillingDemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrBillableVisits_BdrInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "BdrInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrBillableVisits_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrBillableTasks",
                columns: table => new
                {
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillableTasks", x => x.TaskGuid);
                    table.ForeignKey(
                        name: "FK_BdrBillableTasks_BdrBillableVisits_VisitGuid",
                        column: x => x.VisitGuid,
                        principalTable: "BdrBillableVisits",
                        principalColumn: "VisitGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableTasks_VisitGuid",
                table: "BdrBillableTasks",
                column: "VisitGuid");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableVisits_BillingDemandId",
                table: "BdrBillableVisits",
                column: "BillingDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableVisits_InvoiceId",
                table: "BdrBillableVisits",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableVisits_StudyExecutionIdentifier",
                table: "BdrBillableVisits",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillingDemands_StudyExecutionIdentifier",
                table: "BdrBillingDemands",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrInvoices_StudyExecutionIdentifier",
                table: "BdrInvoices",
                column: "StudyExecutionIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdrBillableTasks");

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
