using MSME.Core.Domain;
using MSME.Infrastructure;

namespace MSME.UnitTests;

public class UnitTest1
{


    private PokemonRuleEngine SystemUnderTest => new PokemonRuleEngine();


    [Fact]
    public async Task TestBaseExperience()
    {

      PokemonDetail left = new PokemonDetail();
      left.Base_Experience = int.MaxValue;
      left.Name = "cnn";
      left.Type = "habs";

      PokemonDetail right = new PokemonDetail();
      right.Base_Experience = 0;
      right.Name = "csharp";
      right.Type = "nordiques";

      _ = await SystemUnderTest.Fight(left, right);

      Assert.True(left.Win > 0);
      Assert.True(right.Losses > 0);
    }


    [Fact]
    public async Task TestBaseExperienceRightSideWinning()
    {
      PokemonDetail left = new PokemonDetail();
      left.Base_Experience = 1;
      left.Name = "cnn";
      left.Type = "habs";

      PokemonDetail right = new PokemonDetail();
      right.Base_Experience = 10;
      right.Name = "csharp";
      right.Type = "nordiques";

      _ = await SystemUnderTest.Fight(left, right);

      Assert.True(left.Losses > 0);
      Assert.True(right.Win > 0);
    }


    [Fact]
    public async Task TestTies()
    {
      PokemonDetail left = new PokemonDetail();
      left.Base_Experience = 0;
      left.Name = "cnn";
      left.Type = "habs";

      PokemonDetail right = new PokemonDetail();
      right.Base_Experience = 0;
      right.Name = "csharp";
      right.Type = "nordiques";

      _ = await SystemUnderTest.Fight(left, right);


      Assert.True(left.Ties > 0);
      Assert.True(left.Ties > 0);

      Assert.True(right.Ties > 0);
      Assert.True(right.Ties > 0);
    }
}
