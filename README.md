Laurus.UiTest
=============

Page builder based UI Testing Meta-Framework


How to use:
I like the concept of a strongly typed ineterface that represents the controls on a page, so that's what this framework does.  A map for www.google.com might look like this:

public interface IGooglePage : IPage
{
  [Locator("q")]
  IEditable SearchBox { get; set; }
  
  [Locator("btnK")]
  IClickable SearchButton { get; set; }
}

Once you have a map, you're ready to write tests.  There are or will be various implementation of the base framework for different test drivers.  Right now there's only a Selenium one.  
