## Suggested Extensions for Visual Studio

[![Build status](https://ci.appveyor.com/api/projects/status/fmu7jnie15aj48j4?svg=true)](https://ci.appveyor.com/project/madskristensen/solutionextensions)

Download from the
[Visual Studio Gallery](https://visualstudiogallery.msdn.microsoft.com/3be88243-8bf1-407a-a7ca-a968d0de2d59)
or get
[nightly build](http://vsixgallery.com/extension/51b81721-cf4e-4ce0-a595-972b1ca2a186/).

## Features

- Suggested extensions
  - Suggest missing extensions for unknown files
  - Installs missing extensions easily
  - Show a list of generally suggested extension
- Solution specific extensions
  - The **.vsext** file
  - Intellisense

## Suggested extensions

### Unknown file types

When you open a file type that Visual Studio doesn't provide
any tooling for, a yellow info bar shows up offering 1 or more
available extensions to install.

![InfoBar](art/infobar.png)

You can either chose to install one or more of these extensions
or chose not to be notified again for this particular file
type.

### Install extensions...

When clicking **Install extensions...** in the yellow info bar,
you are presented with a list of extensions for the particular
file type.

![Install missing extensions](art/dialog-install-missing.png)

Just check the extensions you want to install and it will
be installed automatically for you. After installation a new
popup will appear to let you restart Visual Studio.

![Prompt for restart](art/prompt-restart.png)

This is optional, but the newly installed extensions will not
take effect before a restart.

### Ignore file type

When clicking **Ignore file type** on the yellow info bar it
will not show again for the particular info. However, you can
still see the list of suggested extensions by clicking on a
new button on the Standard toolbar.

![Toolbar suggested extensions](art/toolbar-suggested-extensions.png)

That will show the same dialog as before, but now it will also
include generally suggested extensions.

![Dialog suggested extensions](art/dialog-suggested-extensions.png)

> To suggest new extensions for the list, please send a PR
> to [this JSON file](https://github.com/madskristensen/SolutionExtensions/blob/master/src/JSON/Schema/suggestions.json).

## Solution specific extensions

This is great for teams and open source project owners to make
sure that any needed extensions are being installed by the
developers opening and working on that solution.

### Mandatory and optional extensions

When opening a solution in Visual Studio that has already
specified which extensions the user should be using with
said solution, this dialog automatically pops up.

![Dialog missing extensions](art/dialog-missing-extensions.png)

The user is only prompted to install extensions if any
mandatory extensions have been specified and they have not
already been installed.

The user can always decide not to install the extensions and
even specify not to be prompted again for a specific solution.

### Specifying the solution extensions

Specifying which extensions should be used with any solution
is easy. Use the dropdown on the Standard toolbar to
modify solution extensions.

![alt text](art/modify-solution-extensions.png)

That will create a JSON file next to the solution with a
**.vsext** extension.

![Extension solution file](art/vsext-on-disk.png)

The **.vsext** file must have the same name as the **.sln**
file.

After modifying the JSON file, it could look like this:

```json
{
  "extensions": {
    "mandatory": [
      {
        "name": "EditorConfig",
        "productId": "EditorConfig..5cd8e6a2-be43-4fcc-a345-40f6cc1e9c9f",
        "link": "https://visualstudiogallery.msdn.microsoft.com/c8bccfe2-650c-4b42-bc5c-845e21f96328",
        "description": "This makes sure that everyone uses correct spaces and indentation."
      },
      {
        "name": "Extensibility Tools 2015",
        "productId": "f8330d54-0469-43a7-8fc0-7f19febeb897",
        "link": "https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6",
        "description": "Used for editing the '.vsct' file in the root of this project."
      }
    ],
    "optional": [
      {
        "name": "YAML Editor",
        "productId": "YamlDotNetEditor..074a7b74-655b-409c-b5ac-a028f12d6e89",
        "link": "https://visualstudiogallery.msdn.microsoft.com/34423c06-f756-4721-8394-bc3d23b91ca7",
        "description": "This is handy for editing the 'appveyor.yml' file."
      }
    ]
  }
}
```

### Intellisense

When editing the **.vsext** file you get full Intellisense
for all your installed extensions.

![Intellisense](art/intellisense.png)

It even shows the extension icons to make it easy to identify
the right extensions.

> The __productId__ is the `productID` or `Identifier` found
> in an extension's `.vsixmanifest` file. With the Intellisense
> this is all automatically discovered for you.

## Contribute

The more relevant extension suggestions there are, the better
this extension becomes. Please feel free to send pull requests
with additional extensions to
[this JSON file](https://github.com/madskristensen/SolutionExtensions/blob/master/src/JSON/Schema/suggestions.json).

## License
[Apache 2.0](LICENSE)