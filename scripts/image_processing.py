import cv2
import numpy as np
import os
from os.path import isfile, join

def get_image_file(path):
    file = [f for f in os.listdir(path) if 'original_layout' in f and isfile(join(path, f))]
    try:
        return file[0]
    except IndexError:
        return None

def image_processing(path, file):

    img = cv2.imread(join(path, file))
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # edges = cv2.Canny(gray,50,150,apertureSize = 3)
    edges = cv2.Canny(gray,10,70)

    kernel = np.ones((5,5),np.uint8)
    closing = cv2.morphologyEx(edges, cv2.MORPH_CLOSE, kernel, iterations=4)


    kernel = np.ones((7,7),np.uint8)
    dilation = cv2.dilate(closing,kernel,iterations = 3)

    inv = cv2.bitwise_not(dilation)

    cv2.imwrite(path + '/layout.png', inv)

    os.remove(join(path, file))

    # cv2.imshow("img", img)
    # cv2.imshow("edges", edges)
    # cv2.imshow("closing", closing)
    # cv2.imshow("dilation", dilation)
    # cv2.imshow("inv", inv)

    # cv2.waitKey(0)
    # cv2.destroyAllWindows()
