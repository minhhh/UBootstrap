# Unity Bootstrap

This is a base project that will let you quickly bootstrap a new Unity5+ project.

When you start a new project, you will want to reuse the useful tools from your previous project, or import those convenient plugins. Doing this is a bit tedious, moreover, you might forget to import tools that might be helpful in the long term. There has to be a better way to structure the reusable part of your project.

An option is to copy the code from other project directly. However, this approach makes it hard to track which version of the code you get. A better approach is to "link" the code from other repos into your project, so the only included code in your project is the part that cannot be easily put in their own repos.

To link the code from other projects we can use `git submodule` or `subtree`. This is ok until you have several projects that depends on the same project. Then you will have to carefully symlink the correct parts of the submodules, and/or use some tricks to make sure you don't include multiple copies of the same piece code, or the incorrect commit of some piece of code. This is the problem of package and dependency management and we will solve it with `npm` and `yarn`.

The Setup section will explain how you assimilate code from other self-contained packages into this project.

## Setup

1. Clone this repo
1. Install `npm` and `yarn`
1. Update `package.json` to include your interested dependent packages
1. Run `npm run unity` and wait for it to install all necessary packages. Make sure that you setup default user `git` when accessing `github.com`, by adding the following piece of code to `~/.ssh/config`

    ```
    Host github.com
        User git
    ```
1. After running `npm run unity` you should have all the necessary code in your `Assets` folder

## Plugin Setup
To turn a project into a plugin compatible with `npm`, you will have to use a structure similar to https://github.com/minhhh/UBootstrap.Core

1. Copy `index.js`, `package.json`, `p.json` from the sample project to your project.
2. Modify the package name in `package.json` accordingly. Any dependencies should also be declared here. It is recommended to use specific hash/tag instead of relying on `npm` or `yarn`, like so: ssh://github.com/substack/node-mkdirp.git#0.5.1
3. Move your project code inside the correct folders in `Assets`
    * If your project name is `MyProject`, then create a folder named `MyProject` in `Assets`
    * Any code that might not be needed in the project that uses your plugin can be put into `MyProject/Scripts`
    * Code and Resources that will always be needed should be put inside `MyProject/Plugins/MyProject`. The reason there need to be subfolders in `MyProject/Plugins` is that it allows you to flexibly add more subplugins in the future. For instance, in many plugins, the folder structure looks like this: `MyCompany/Plugins/Common`, `MyCompany/Plugins/Plugin1`, `MyCompany/Plugins/Plugin2`. This way the `Common` folder can be reused between your plugin without the risk of name collision.
4. Modify `p.json`. This file contains the list of folders that need to be copied to the user's project. In our case, we can simply put `MyProject`

## Troubleshooting
### `npm run unity` seems to freeze
Sometimes `yarn` will freeze when fetching packages so you can try rerun the command `npm run unity` several times if you encounter this problem.


## Changelog

**0.0.2**

* Include `uboostrap-texturedithering`, `uboostrap-webp`

**0.0.1**

* Initial setup

<br/>
