from subprocess import run
import os


def png_to_pnm(path):
    if not os.path.isfile(path + '/layout.png'):
        print("layout.png doesn't exist")
        exit(1)
    magick_link = 'https://imagemagick.org/script/download.php'
    command = f'magick convert {path}/layout.png {path}/layout.pnm'        # PNG to PNM
    try:
        run(command.split())
    except OSError:
        print("looks like you don't have ImageMagick installed.")
        print(f"You can install it from this link {magick_link}")
        print('If you already installed it make, sure to add the installation directory to the Environment Variables')
        exit(1)

def pnm_to_csv(path):
    if not os.path.isfile(path + '/layout.pnm'):
        print("layout.pnm doesn't exist")
        exit(1)
    potrace_link = 'http://potrace.sourceforge.net/'
    command = f'potrace {path}/layout.pnm -s -o {path}/layout.svg'         # PNM to SVG
    try:
        run(command.split())
    except OSError:
        print("looks like you don't have Potrace installed.")
        print(f"You can install it from this link {potrace_link}")
        print('If you already installed it, make sure to add the installation directory to the Environment Variables')
        exit(1)
    finally:
        os.remove(path + '/layout.pnm')

def csv_to_stl(path):
    if not os.path.isfile(path + '/layout.svg'):
        print("layout.svg doesn't exist")
        exit(1)
    blender_link = 'https://www.blender.org/download/'
    command = f"blender --background --python {os.path.join(path, '..')}/create_model.py"
    try:
        run(command.split())
    except OSError:
        print("looks like you don't have Blender installed.")
        print(f"You can install it from this link {blender_link}")
        print('If you already installed it, make sure to add the installation directory to the Environment Variables')
        exit(1)
    finally:
        os.remove(path + '/layout.svg')
