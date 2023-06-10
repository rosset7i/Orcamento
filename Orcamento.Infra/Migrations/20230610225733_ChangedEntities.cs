using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orcamento.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Fornecedor_FornecedorId",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_IdFornecedor",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoOrcamento_Orcamento_IdOrcamento",
                table: "ProdutoOrcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoOrcamento_Produto_IdProduto",
                table: "ProdutoOrcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoOrcamento",
                table: "ProdutoOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoOrcamento_IdOrcamento",
                table: "ProdutoOrcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdFornecedor",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamento",
                table: "Orcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "ProdutoOrcamento",
                newName: "produtoorcamento");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "produto");

            migrationBuilder.RenameTable(
                name: "Orcamento",
                newName: "orcamento");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "fornecedor");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "users",
                newName: "passwordsalt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "produtoorcamento",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "produtoorcamento",
                newName: "idproduto");

            migrationBuilder.RenameColumn(
                name: "IdOrcamento",
                table: "produtoorcamento",
                newName: "idorcamento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "produtoorcamento",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoOrcamento_IdProduto",
                table: "produtoorcamento",
                newName: "IX_produtoorcamento_idproduto");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "produto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "produto",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "produto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PrecoTotal",
                table: "orcamento",
                newName: "precototal");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "orcamento",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "orcamento",
                newName: "fornecedorid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orcamento",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "orcamento",
                newName: "datadecriacao");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamento_FornecedorId",
                table: "orcamento",
                newName: "IX_orcamento_fornecedorid");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "fornecedor",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "fornecedor",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "fornecedor",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fornecedor",
                newName: "id");

            migrationBuilder.AddColumn<Guid>(
                name: "orcamentoentityid",
                table: "produtoorcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "precototal",
                table: "produtoorcamento",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "precounitario",
                table: "produtoorcamento",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "marca",
                table: "produto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtoorcamento",
                table: "produtoorcamento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orcamento",
                table: "orcamento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fornecedor",
                table: "fornecedor",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_produtoorcamento_orcamentoentityid",
                table: "produtoorcamento",
                column: "orcamentoentityid");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamento_fornecedor_fornecedorid",
                table: "orcamento",
                column: "fornecedorid",
                principalTable: "fornecedor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtoorcamento_orcamento_orcamentoentityid",
                table: "produtoorcamento",
                column: "orcamentoentityid",
                principalTable: "orcamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtoorcamento_produto_idproduto",
                table: "produtoorcamento",
                column: "idproduto",
                principalTable: "produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamento_fornecedor_fornecedorid",
                table: "orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_produtoorcamento_orcamento_orcamentoentityid",
                table: "produtoorcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_produtoorcamento_produto_idproduto",
                table: "produtoorcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produtoorcamento",
                table: "produtoorcamento");

            migrationBuilder.DropIndex(
                name: "IX_produtoorcamento_orcamentoentityid",
                table: "produtoorcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orcamento",
                table: "orcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fornecedor",
                table: "fornecedor");

            migrationBuilder.DropColumn(
                name: "orcamentoentityid",
                table: "produtoorcamento");

            migrationBuilder.DropColumn(
                name: "precototal",
                table: "produtoorcamento");

            migrationBuilder.DropColumn(
                name: "precounitario",
                table: "produtoorcamento");

            migrationBuilder.DropColumn(
                name: "marca",
                table: "produto");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "produtoorcamento",
                newName: "ProdutoOrcamento");

            migrationBuilder.RenameTable(
                name: "produto",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "orcamento",
                newName: "Orcamento");

            migrationBuilder.RenameTable(
                name: "fornecedor",
                newName: "Fornecedor");

            migrationBuilder.RenameColumn(
                name: "passwordsalt",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "ProdutoOrcamento",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "idproduto",
                table: "ProdutoOrcamento",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "idorcamento",
                table: "ProdutoOrcamento",
                newName: "IdOrcamento");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProdutoOrcamento",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_produtoorcamento_idproduto",
                table: "ProdutoOrcamento",
                newName: "IX_ProdutoOrcamento_IdProduto");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Produto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Produto",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Produto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "precototal",
                table: "Orcamento",
                newName: "PrecoTotal");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Orcamento",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "fornecedorid",
                table: "Orcamento",
                newName: "FornecedorId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orcamento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "datadecriacao",
                table: "Orcamento",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_orcamento_fornecedorid",
                table: "Orcamento",
                newName: "IX_Orcamento_FornecedorId");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Fornecedor",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Fornecedor",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Fornecedor",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Fornecedor",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "IdFornecedor",
                table: "Produto",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Produto",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoOrcamento",
                table: "ProdutoOrcamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamento",
                table: "Orcamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoOrcamento_IdOrcamento",
                table: "ProdutoOrcamento",
                column: "IdOrcamento");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdFornecedor",
                table: "Produto",
                column: "IdFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Fornecedor_FornecedorId",
                table: "Orcamento",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_IdFornecedor",
                table: "Produto",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoOrcamento_Orcamento_IdOrcamento",
                table: "ProdutoOrcamento",
                column: "IdOrcamento",
                principalTable: "Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoOrcamento_Produto_IdProduto",
                table: "ProdutoOrcamento",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
