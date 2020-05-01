import os
import cv2
import numpy as np


full_path = os.path.realpath(__file__)
path = os.path.dirname(full_path)

img = cv2.imread(path + '/layout.jpeg')
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# edges = cv2.Canny(gray,50,150,apertureSize = 3)
edges = cv2.Canny(gray,10,70)

kernel = np.ones((5,5),np.uint8)
closing = cv2.morphologyEx(edges, cv2.MORPH_CLOSE, kernel, iterations=4)


kernel = np.ones((9,9),np.uint8)
dilation = cv2.dilate(closing,kernel,iterations = 3)

inv = cv2.bitwise_not(dilation)

cv2.imwrite(path + '/layout.png', inv)

# cv2.imshow("img", img)
# cv2.imshow("edges", edges)
# cv2.imshow("closing", closing)
# cv2.imshow("dilation", dilation)
# cv2.imshow("inv", inv)

# cv2.waitKey(0)
# cv2.destroyAllWindows()
