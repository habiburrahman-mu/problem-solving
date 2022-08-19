row = 5
mat = [list(map(int,input().split())) for i in range(row)]
for i in range(row):
	for j in range(row):
		if mat[i][j] == 1:
			move = abs(2-i)+abs(2-j)
print(move)
