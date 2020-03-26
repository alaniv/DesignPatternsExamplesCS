using System;
using System.Collections;

namespace Composite
{
    interface AbstractFile //Component
    {
        void dir(int tabs);
    }

    class File : AbstractFile //Leaf
    {
        private String name;
        public File(String name)
        {
            this.name = name;
        }
        public void dir(int tabs)
        {
            Console.WriteLine(new String('\t', tabs) + name);
        }
    }

    class Directory : AbstractFile //Composite
    {
        private String name;
        private ArrayList includedFiles = new ArrayList();

        public Directory(String name)
        {
            this.name = name;
        }

        public void add(AbstractFile obj)
        {
            includedFiles.Add(obj);
        }

        public void dir(int tabs)
        {
            Console.WriteLine(new String('\t', tabs) + name);
            foreach (AbstractFile includedFile in includedFiles)
            {
                includedFile.dir(tabs + 1);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Composite>");
            Directory c = new Directory("C");
            Directory photos = new Directory("Photos");
            Directory games = new Directory("Games");
            File pokemon = new File("Pokemon.exe");
            File meme = new File("meme.jpg");
            File meme2 = new File("meme2.jpg");
            File video = new File("test.mp4");
            c.add(photos);
            c.add(games);
            c.add(video);
            photos.add(meme);
            photos.add(meme2);
            games.add(pokemon);
            c.dir(0);
        }
    }
}
