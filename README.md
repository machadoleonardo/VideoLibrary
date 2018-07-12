VideoLibray
==============

Sistema de gerenciamento de Filmes e gêneros

### Instalação

1. Faça o clone deste projeto a partir do repositório indicado no email
2. Abra o SQL Server em uma conexão localhost e crie uma base de dados com o nome "VideoLibraryDB";
3. Abra a solução no Visual Studio e execute o comando "Update-Database"
4. Execute o programa

### Decisões de Projeto
1. Todas as exclusões no sistema são exclusões lógicas
2. Um filme pode ser excluído sem nenhuma restrição
3. Um gênero pode ser removido desde que não esteja associado a um filme ativo/não excluído
4. Caso deseje excluir é necessário ou editar o filme ou removê-lo
5. A ambas as entidades possuem opção para remoção de forma individual ou através de múltipla seleção.




