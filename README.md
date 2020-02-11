# LiveDump
A simple memory dumper

### Intro
I’m a fan of 010 Editor‘s templating system they have in place where you can write layouts for hex dumps or file formats I use it in almost all of my research/reversing. 
More information about that can be found here even though the hex editor has a built in system to open a live processes memory it’s not really great. 
I needed a system where the data I was looking at was live and updated almost instantaneously so I wrote LiveDump.

LiveDump is a simple memory dumper which will either dump a region of memory once to a file or constantly dump it every X many milliseconds, this way I can see the data updated almost live in 010 editor and make use of their templating to reverse a portion of a data structure or class object. 
There are things like Reclass which are purposely built for this reason which I do use however my own personal preference is the templating feature built into 010 editor as it’s very robust and you incorporate loops and logic into it to display the data out how you want it.

![Screenshot](http://github.com/cra0kalo/LiveDump/Docs/screenshot01.png)


