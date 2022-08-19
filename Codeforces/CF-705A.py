n = int(input())
st=""

for i in range(1,n):
	if i%2 != 0:
		st = f"{st}I hate that "
	else:
		st = f"{st}I love that "

if n%2==1:
	st = f"{st}I hate it"
if n%2==0:
	st = f"{st}I love it"

print(st)