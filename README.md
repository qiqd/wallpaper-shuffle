# WallpaperShuffle

WallpaperShuffle is a Windows application that allows users to obtain various types of wallpapers online through custom configurations, ensuring that each random wallpaper change results in a different image. The app **must be run with administrator privileges** to access all its features.

## Key Features

- **Online Wallpaper Fetching**: Dynamically load wallpapers from specified sources.
- **Randomized Wallpapers**: Each wallpaper change will provide a different image.
- **Customizable Sources**: Easily configure wallpaper sources and parameters using a JSON file.
- **Auto Start on Boot**: Automatically launch on system startup (requires admin rights).
- **High Privilege Support**: Ensures smooth operation with elevated permissions.

## Usage Guide

### I. Enable Slideshow Mode

1. Open **Settings**.
2. Go to **Personalization**.
3. Click on the **Background** tab.
4. Set the background type to **Slideshow**.
5. Choose the wallpaper folder: In the slideshow settings, select the image folder. Please set this folder to the directory where this app downloads and saves wallpapers. This way, newly downloaded wallpapers will automatically be added to the slideshow.

### II. Customize Wallpaper Sources

Wallpaper sources are configured via a JSON file. Example format:

```json
[
  {
    "title": "Bing Random HD Wallpaper",
    "url": "https://bing.img.run/rand_uhd.php",
    "arguments": ["width=1090", "height=9090"]
  }
]
```

- `title`: Name of the wallpaper source.
- `url`: API endpoint for fetching the wallpaper.
- `arguments`: Path parameters to include in the request. For example, specify width and height. If needed, pass them as an array like `["width=1090", "height=9090"]`; if none, use `null`.

### III. Installation & Launch

#### Installation

1. Download the latest installer and run it.
2. Follow the installation prompts.
3. To enable auto-start on boot, ensure you run the app **as administrator** during the first launch.

#### Running the App

Since WallpaperShuffle requires access to system-level resources, it **must be launched with administrator privileges**. To start the application:

- Right-click the desktop shortcut or Start menu icon and select **"Run as administrator"**.

### IV. Enable Auto Start on Boot

To make WallpaperShuffle launch automatically when your system starts:

1. **First Run**: On the initial launch, run the app **as administrator**. This will allow the app to create a scheduled task that runs at startup with elevated permissions.
2. **Verify Setup**: You can confirm the task is created by opening **Task Scheduler**, navigating to **Task Scheduler Library**, and looking for a task named **"WallpaperShuffle"**.

### V. Frequently Asked Questions

#### 1. Can I use this app without administrator rights?

- No. WallpaperShuffle **requires administrator privileges** to function properly. If you do not have admin rights, please contact your system administrator for assistance.

#### 2. Why does the app need administrator permissions?

- Certain features such as auto-start, writing to protected directories, or scheduling tasks require elevated permissions to operate correctly.

---
