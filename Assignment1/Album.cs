using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Album
    {
        private string albumName = string.Empty;
        private string artistName = string.Empty;
        private int numOfTracks;

        public void Start()
        {
            ReadAlbumName();
            ReadArtist();
            ReadnumOfTracks();
            DisplayInputs();
        }

        public void ReadAlbumName()
        {
            Console.WriteLine("What is the name of your favourite music album?");
            albumName = Console.ReadLine();
        }

        public void ReadArtist()
        {
            Console.WriteLine("What is the name of the Artist or Band for " + albumName);
            artistName = Console.ReadLine();
        }

        public void ReadnumOfTracks()
        {
            Console.WriteLine("How many tracks does " + albumName + " have?");
            numOfTracks = int.Parse(Console.ReadLine());
        }

        public void DisplayInputs()
        {
            Console.WriteLine("Album Name: " + albumName);
            Console.WriteLine("Artist Name: " + artistName);
            Console.WriteLine("Number of Tracks: " + numOfTracks);
            Console.WriteLine("Enjoy listening!");
        }

    }
}
