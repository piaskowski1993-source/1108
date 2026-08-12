namespace drone.Tests;

public class DroneModelTests
{
    [Fact]
    public void Construct_WIthValidValues_SetsProperties()
    {var drone = new DroneModel ("Falcon", maxCheckpoints : 5, delayMs : 100);
    Assert.Equal("Falcon", drone.Name);
    Assert.Equal(5, drone.MaxCheckpoints);
    Assert.Equal(100, drone.DelayMs);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Constructor_WithMissingName_Throws(string? name)
    {
        Assert.Throws<ArgumentException>(() => new DroneModel (name!, maxCheckpoints : 5, delayMs : 100));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]

    public void Constructor_WithNonPositiveMaxCheckpoints_Throws (int maxCheckpoints)
    {
        Assert.Throws<ArgumentException>(() => new DroneModel ("Falcon", maxCheckpoints, delayMs : 100));
    }

    [Fact]
     public void Constructor_WithNegativeDelayMs_Throws()
    {
        Assert.Throws<ArgumentException>(() => new DroneModel ("Falcon", maxCheckpoints : 5, delayMs : -1));
    }
    }