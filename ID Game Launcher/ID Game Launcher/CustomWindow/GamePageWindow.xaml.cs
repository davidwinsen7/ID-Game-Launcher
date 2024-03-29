﻿using System;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.ComponentModel;

namespace ID_Game_Launcher.CustomWindow
{
    /// <summary>
    /// Interaction logic for GamePageWindow.xaml
    /// </summary>
    /// 
    enum GameIndex
    {
        AGENT_BABY,
        SNOW_YARD,
        LAST_LINE,
        MOON_CONQUEST
    }

    enum LauncherStatus
    {
        ready,
        failed,
        needDownload,
        downloadingGame,
        needUpdate,
        downloadingUpdate
    }

    public partial class GamePageWindow : Window
    {
        private string rootDirectory; 
        private string libraryDirectory; //directory of all the games
        private string gameExePath;
        private string versionFile;
        private string gameZipPath;
        private string gameFolderName;
        private string gameExeName;

        private string gameURL;
        private string gameVersionURL;

        private LauncherStatus _status;
        internal LauncherStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case LauncherStatus.ready:
                        PlayButton.Content = "Play";
                        uninstallDropdown.Opacity = 1f;
                        break;
                    case LauncherStatus.failed:
                        PlayButton.Content = "Installation Error!";
                        break;
                    case LauncherStatus.needDownload:
                        PlayButton.Content = "Download";
                        uninstallDropdown.Opacity = 0.5f;
                        break;
                    case LauncherStatus.downloadingGame:
                        PlayButton.Content = "Downloading...";
                        break;
                    case LauncherStatus.needUpdate:
                        PlayButton.Content = "Update";
                        uninstallDropdown.Opacity = 1f;
                        break;
                    case LauncherStatus.downloadingUpdate:
                        PlayButton.Content = "Updating...";
                        break;
                    default:
                        break;
                }
            }
        }

        private string[] gameDesc = new string[MainWindow.numOfGames];
        private GameIndex gameIndex;
        public GamePageWindow(GameSlot gameSlot)
        {
            InitializeComponent();
            Title = gameSlot.GameName.Content.ToString();
            displayImage.Source = gameSlot.GameImage.Source;
            displayName.Content = gameSlot.GameName.Content.ToString();

            switch (Title)
            {
                case "Agent Baby":
                    gameIndex = GameIndex.AGENT_BABY;
                    gameURL = "https://www.dropbox.com/s/st0enrlwwqbpnxj/Agent%20Baby.zip?dl=1";
                    gameVersionURL = "https://www.dropbox.com/s/u64mub576mpi1oi/Version.txt?dl=1";
                    gameDesc[(int)GameIndex.AGENT_BABY] = "Play as Agent Baby! a secret agent who possesses a powerful weapon that can rewind people to younger age! " +
                                                   "Infiltrate the evil lair and make your way to the boss in this fun little 2d platformer!";
                    break;
                case "Snow-Yard":
                    gameIndex = GameIndex.SNOW_YARD;
                    gameURL = "https://www.dropbox.com/s/nhbevzh29judnc2/Snow-yard.zip?dl=1";
                    gameVersionURL = "https://www.dropbox.com/s/gi54see82vd89i6/Version.txt?dl=1";
                    gameDesc[(int)GameIndex.SNOW_YARD] = "Shoot as many snowman as you can within the time limit! Share and compete with your friends to see who can score the highest! " +
                                                   "Be careful, the snowman may slide on the slippery floor!";
                    break;
                case "Last Line":
                    gameIndex = GameIndex.LAST_LINE;
                    gameURL = "https://www.dropbox.com/s/gvg5f4lnrdughsg/Last%20Line.zip?dl=1";
                    gameVersionURL = "https://www.dropbox.com/s/8802ke17c7z64ze/Version.txt?dl=1";
                    gameDesc[(int)GameIndex.LAST_LINE] = "The Robots are trying to take control! All efforts had been done but all we can do left is to defend. " +
                                                   "We're at the Last Line of defense now. Join the battle to prevent Human Pride from being taken by The Robots and end this once and for all!";
                    break;
                case "Moon Conquest":
                    gameIndex = GameIndex.MOON_CONQUEST;
                    gameURL = "https://www.dropbox.com/s/qu4d4i9v2wjxd9v/Moon%20Conquest.zip?dl=1";
                    gameVersionURL = "https://www.dropbox.com/s/xp13g7a66mtd04y/Version.txt.txt?dl=1";
                    gameDesc[(int)GameIndex.MOON_CONQUEST] = "Play as a guy on his journey to the moon. Conquer the overweight spaceship, kick every other passengers off the ship, and go to the moon!";
                    break;
            }
            gameDescription.Text = gameDesc[(int)gameIndex];

           
            gameFolderName = Title;
            gameExeName = Title + ".exe";

            rootDirectory = Directory.GetCurrentDirectory();
            libraryDirectory = directoryManagement.currentDirectory;
            versionFile = Path.Combine(libraryDirectory, gameFolderName, "Version.txt");
            gameZipPath = Path.Combine(libraryDirectory, gameFolderName + ".zip");
            gameExePath = Path.Combine(libraryDirectory, gameFolderName, gameExeName);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            if (Status == LauncherStatus.needDownload)
            {
                Version onlineVersion = new Version(webClient.DownloadString(gameVersionURL));
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);            
                webClient.DownloadFileAsync(new Uri(gameURL), gameZipPath, onlineVersion);
                Status = LauncherStatus.downloadingGame;
            }
            else if(Status == LauncherStatus.needUpdate)
            {
                Version onlineVersion = new Version(webClient.DownloadString(gameVersionURL));
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);
                webClient.DownloadFileAsync(new Uri(gameURL), gameZipPath, onlineVersion);
                Status = LauncherStatus.downloadingUpdate;
            }
            else if (Status == LauncherStatus.ready)
            {
                Launcher.PlayGame(gameExePath);
            }
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgressBar.Visibility = Visibility.Visible;
            downloadPercentage.Visibility = Visibility.Visible;
            downloadProgressBar.Value = e.ProgressPercentage;
            downloadPercentage.Content = e.ProgressPercentage + " %";
        }

        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(gameZipPath, libraryDirectory, true);
                
                File.Delete(gameZipPath);

                File.WriteAllText(versionFile, onlineVersion);
                Status = LauncherStatus.ready;

                downloadProgressBar.Visibility = Visibility.Hidden;
                downloadPercentage.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error finishing download: {ex}");
            }
        }

        private void CheckForUpdates()
        {
            if (File.Exists(versionFile))
            {
                Version localVersion = new Version(File.ReadAllText(versionFile));
                try
                {
                    WebClient webClient = new WebClient();
                    Version onlineVersion = new Version(webClient.DownloadString(gameVersionURL));

                    if (onlineVersion.isDifferentThan(localVersion))
                    {
                        InstallGameFiles(true);
                    }
                    else
                    {
                        Status = LauncherStatus.ready;
                    }
                }
                catch(Exception ex)
                {
                    Status = LauncherStatus.failed;
                    MessageBox.Show($"Error checking for game updates: {ex}");
                }
            }
            else
            {
                InstallGameFiles(false);
            }
        }

        private void InstallGameFiles(bool _isUpdate)
        {
            try
            {
                if (_isUpdate)
                {
                    Status = LauncherStatus.needUpdate;
                }
                else
                {
                    Status = LauncherStatus.needDownload;                  
                }
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error installing game files: {ex}");
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        struct Version
        {
            internal static Version zero = new Version(0, 0, 0);

            private short major;
            private short minor;
            private short subMinor;

            internal Version(short _major, short _minor, short _subMinor)
            {
                major = _major;
                minor = _minor;
                subMinor = _subMinor;
            }

            internal Version(string _version)
            {
                string[] _versionStrings = _version.Split('.');
                if (_versionStrings.Length != 3)
                {
                    major = 0;
                    minor = 0;
                    subMinor = 0;
                    return;
                }

                major = short.Parse(_versionStrings[0]);
                minor = short.Parse(_versionStrings[1]);
                subMinor = short.Parse(_versionStrings[2]);
            }

            internal bool isDifferentThan(Version _otherVersion)
            {
                if (major != _otherVersion.major)
                {
                    return true;
                }
                else
                {
                    if (minor != _otherVersion.minor)
                    {
                        return true;
                    }
                    else
                    {
                        if (subMinor != _otherVersion.subMinor)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public override string ToString()
            {
                return $"{major}.{minor}.{subMinor}";
            }
        }

        private void backButton_MouseEnter(object sender, MouseEventArgs e)
        {
            backButton.Width = 55;
            backButton.Height = 55;
            backButton.Opacity = 0.5;
        }

        private void backButton_MouseLeave(object sender, MouseEventArgs e)
        {
            backButton.Width = 50;
            backButton.Height = 50;
            backButton.Opacity = 1;
        }

        private void backButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void uninstallDropdown_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Status == LauncherStatus.ready)
                uninstallDropdown.Opacity = 0.5f;
        }

        private void uninstallDropdown_MouseLeave(object sender, MouseEventArgs e)
        {
            if(Status == LauncherStatus.ready)
                uninstallDropdown.Opacity = 1f;
        }

        private void uninstallDropdown_Click(object sender, RoutedEventArgs e)
        {
            if(Status == LauncherStatus.ready || Status == LauncherStatus.needUpdate)
                MainContextMenu.IsOpen = true;
        }

        private void uninstallMenu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Are you sure you want to uninstall the game?", "Uninstall Game", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    Directory.Delete(Path.Combine(libraryDirectory, gameFolderName), true);
                    MessageBox.Show("Successfully uninstalled the game!", "Uninstall Sucessful");
                    Status = LauncherStatus.needDownload;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error uninstalling the game: {ex}");
                }
            }
        }
    }
}
