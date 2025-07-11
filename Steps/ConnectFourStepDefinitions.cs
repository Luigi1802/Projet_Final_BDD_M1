namespace Projet_Final_BDD_M1.Steps;

[Binding]
public sealed class ConnectFourStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public ConnectFourStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }


    [Given(@"a new connect four grid")]
    public void GivenANewConnectFourGrid()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the grid should be empty")]
    public void ThenTheGridShouldBeEmpty()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"player (.*) plays column (.*)")]
    public void WhenPlayerPlaysColumn(int p0, int p1)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the grid column (.*) row (.*) should be (.*)")]
    public void ThenTheGridColumnRowShouldBe(int p0, int p1, int p2)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"columns (.*) to (.*) should be empty")]
    public void ThenColumnsToShouldBeEmpty(int p0, int p1)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"next row for column (.*) should be (.*)")]
    public void ThenNextRowForColumnShouldBe(int p0, int p1)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the following grid:")]
    public void GivenTheFollowingGrid(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"column (.*) row (.*) should be (.*)")]
    public void ThenColumnRowShouldBe(int p0, int p1, int p2)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"player (.*) should win")]
    public void ThenPlayerShouldWin(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a tie match should be declared")]
    public void ThenATieMatchShouldBeDeclared()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the full column error is thrown")]
    public void ThenTheFullColumnErrorIsThrown()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the column out of bounds error is thrown")]
    public void ThenTheColumnOutOfBoundsErrorIsThrown()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the wrong turn error is thrown")]
    public void ThenTheWrongTurnErrorIsThrown()
    {
        ScenarioContext.StepIsPending();
    }
}