using NUnit.Framework;
// ReSharper disable CommentTypo

namespace UnitTestCommon.Example;

public class Tips
{
    // Método executado antes de cada teste.
    [SetUp]
    public void SetUp()
    {
        // Aqui você pode adicionar código para configurar objetos necessários para os testes,
        // como instâncias de mocks, bancos de dados de teste, etc.
        
        // Esse método é executado antes de cada teste,
        // para garantir que cada teste comece com um ambiente limpo e consistente.
    }

    // Método executado uma única vez antes de todos os testes.
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Aqui você pode adicionar código para configurar objetos que serão compartilhados por todos os testes,
        // como instâncias de bancos de dados de teste que demoram muito para serem criadas.
        
        // Esse método é executado uma única vez,
        // antes de todos os testes, para economizar tempo de execução e garantir que os objetos sejam compartilhados por todos os testes.
    }

    // Método executado após cada teste.
    [TearDown]
    public void TearDown()
    {
        // Aqui você pode adicionar código para limpar objetos criados durante os testes,
        // como mocks ou instâncias de bancos de dados temporários.
        
        // Esse método é executado após cada teste,
        // para garantir que cada teste deixe o ambiente limpo e consistente para o próximo teste.
    }

    // Método executado uma única vez após todos os testes.
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // Aqui você pode adicionar código para limpar objetos criados durante os testes,
        // como mocks ou instâncias de bancos de dados temporários que foram criados no método OneTimeSetUp().
        
        // Esse método é executado uma única vez,
        // após todos os testes, para economizar tempo de execução e limpar objetos criados no método OneTimeSetUp().
    }
}