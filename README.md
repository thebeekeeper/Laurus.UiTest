Laurus.UiTest
=============

Page builder based UI Testing Meta-Framework

I like the concept of a strongly typed interface that represents the controls on a page, so that's what this framework does.  

## Usage

A page for www.google.com might look like this:

```
public interface IGooglePage : IPage
{
  IEditable SearchBox { get; set; }
  
  IClickable SearchButton { get; set; }
}
```

After you've got a page designed you'll need to tell the framework how to find the controls.  Similar to database mappings in Entity Framework you make a class like this:

```
public class GooglePageMap : PageMap<IGooglePage>
{
  pubilc GooglePageMap()
  {
    // Can use a predefined locator...
    AddToMap(x => x.SearchBox, LocatorKey.Name, "q");
    // ... or an arbitrary one
    AddToMap(x => x.SearchButton, "Name", "btnG");
  }
}
```

Once you have a map, you're ready to write tests.  There are or will be various implementation of the base framework for different test drivers.  Right now there's only a Selenium one.  


## NuGet Installation

    Install-Package Laurus.UiTest
    Install-Package Laurus.UiTest.Selenium
