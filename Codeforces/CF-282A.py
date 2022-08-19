n = int(input())
c = 0
for i in range(n):
	st = input()
	if st=="++X" or st=="X++":
		c+=1
	elif st=="--X" or st=="X--":
		c-=1
print(c)