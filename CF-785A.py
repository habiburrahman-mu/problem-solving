n = int(input())
c = 0
for _ in range(n):
	inp = str(input())
	if inp=="Tetrahedron": c+=4
	elif inp=="Cube": c+=6
	elif inp=="Octahedron": c+=8
	elif inp=="Dodecahedron": c+=12
	elif inp=="Icosahedron": c+=20
print(c)