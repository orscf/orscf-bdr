using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalResearch.BillingData.Migrations
{
    /// <inheritdoc />
    public partial class V002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdrVisitBillingRecords");

            migrationBuilder.DropTable(
                name: "BdrBillableVisits");

            migrationBuilder.CreateTable(
                name: "BdrBillableItems",
                columns: table => new
                {
                    BillableItemUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisitProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueExecutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillableItems", x => x.BillableItemUid);
                    table.ForeignKey(
                        name: "FK_BdrBillableItems_BdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "BdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BdrBillingItems",
                columns: table => new
                {
                    BillingItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FixedExecutionState = table.Column<int>(type: "int", nullable: false),
                    FixedPriceOfItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedPriceOfTasks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedTaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasksRelatedInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillableItemUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdrBillingItems", x => x.BillingItemId);
                    table.ForeignKey(
                        name: "FK_BdrBillingItems_BdrBillableItems_BillableItemUid",
                        column: x => x.BillableItemUid,
                        principalTable: "BdrBillableItems",
                        principalColumn: "BillableItemUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrBillingItems_BdrBillingDemands_BillingDemandId",
                        column: x => x.BillingDemandId,
                        principalTable: "BdrBillingDemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BdrBillingItems_BdrInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "BdrInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillableItems_StudyExecutionIdentifier",
                table: "BdrBillableItems",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillingItems_BillableItemUid",
                table: "BdrBillingItems",
                column: "BillableItemUid");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillingItems_BillingDemandId",
                table: "BdrBillingItems",
                column: "BillingDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_BdrBillingItems_InvoiceId",
                table: "BdrBillingItems",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdrBillingItems");

            migrationBuilder.DropTable(
                name: "BdrBillableItems");

            migrationBuilder.CreateTable(
                name: "BdrBillableVisits",
                columns: table => new
                {
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutionEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UniqueExecutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "BdrVisitBillingRecords",
                columns: table => new
                {
                    BillingRecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FixedExecutionState = table.Column<int>(type: "int", nullable: false),
                    FixedPriceOfTasks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedPriceOfVisit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedTaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SponsorValidationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
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
    }
}
