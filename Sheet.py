a = """92
45
57
88
44

98
45
89
353
336
34"""

b = a.split("\n\n")

for i in range(len(b)):
    """print(b[i])"""
    for ii in b[i].split("\n"):
        print(f"{i+109}\t{ii}")
