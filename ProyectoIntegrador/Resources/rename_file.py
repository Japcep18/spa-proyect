import os

REPLACE = "icons8-"
items = [f for f in os.listdir() if f.endswith(".png") and REPLACE in f]
for item in items:
    # print(item.replace(REPLACE, ""))
    os.rename(item, item.replace(REPLACE, ""))