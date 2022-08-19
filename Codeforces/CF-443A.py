inp = input().strip('{').strip('}').split(', ')
m = []
count = 0
for ch in inp:
		if ch != "" and ch not in m:
			m.append(ch)
			count+=1
print(count)