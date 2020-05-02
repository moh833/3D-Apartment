import os
from commands import (png_to_pnm, pnm_to_csv, csv_to_stl)
from image_processing import image_processing, get_image_file

full_path = os.path.dirname(os.path.abspath(__file__))
path = os.path.abspath(os.path.join(full_path, 'images'))

file = get_image_file(path)
if not file:
    print("Upload and image first!")
    exit(1)

try:
    image_processing(path, file)
except Exception as e:
    print(e)
    print("Make sure you have python3 installed with numpy and opencv libraries and try again")
    exit(1)

png_to_pnm(path)
pnm_to_csv(path)
csv_to_stl(path)