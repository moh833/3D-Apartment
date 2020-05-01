from subprocess import run
import os

full_path = os.path.realpath(__file__)
path = os.path.dirname(full_path)

os.chdir(path)

# pip install numpy
# pip install opencv-python
command = 'python image_processing.py'
try:
    run(command.split())
except:
    print("Make sure you have python3 installed with numpy and opencv libraries and try again")
    exit(1)


if not os.path.isfile(path + '/layout.png'):
    print("layout.png doesn't exist")
    exit(1)
magick_link = 'https://imagemagick.org/script/download.php'
command = 'magick convert layout.png layout.pnm'        # PNG to PNM
try:
    run(command.split())
except:
    print("looks like you don't have ImageMagick installed.")
    print(f"You can install it from this link {magick_link}")
    print('If you already installed it make, sure to add the installation directory to the Environment Variables')
    exit(1)


if not os.path.isfile(path + '/layout.pnm'):
    print("layout.pnm doesn't exist")
    exit(1)
potrace_link = 'http://potrace.sourceforge.net/'
command = 'potrace layout.pnm -s -o layout.svg'         # PNM to SVG
try:
    run(command.split())
except:
    print("looks like you don't have Potrace installed.")
    print(f"You can install it from this link {potrace_link}")
    print('If you already installed it, make sure to add the installation directory to the Environment Variables')
    exit(1)
finally:
    os.remove(path + '/layout.pnm')


if not os.path.isfile(path + '/layout.svg'):
    print("layout.svg doesn't exist")
    exit(1)
blender_link = 'https://www.blender.org/download/'
command = 'blender --background --python create_model.py'
try:
    run(command.split())
except:
    print("looks like you don't have Blender installed.")
    print(f"You can install it from this link {blender_link}")
    print('If you already installed it, make sure to add the installation directory to the Environment Variables')
    exit(1)
finally:
    os.remove(path + '/layout.svg')
