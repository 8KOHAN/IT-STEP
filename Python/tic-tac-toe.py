import random
def drawboard(board):
    print("   |   |")
    print(" " + board[7] + " | " + board[8] + " | " + board[9])
    print("   |   |")
    print("---+---+---")
    print("   |   |")
    print(" " + board[4] + " | " + board[5] + " | " + board[6])
    print("   |   |")
    print("---+---+---")
    print("   |   |")
    print(" " + board[1] + " | " + board[2] + " | " + board[3])
    print("   |   |")

def inputplyerletter():
    letter = ''
    while not (letter == 'X' or letter == 'O'):
        print("обери сторону, Х або О")
        letter = input().upper().strip()
    if letter == 'X':
        return ['X', 'O']
    else:
        return ['O', 'X']

def whogofirst():
    if random.randint(0,1) == 0:
        return 'computer'
    else:
        return 'player'
    
def playagain():
    print("ще грати ?yes or no")
    return input().strip().lower().startswith('y')

def makemove(board, letter, move):
    board[move]=letter

def iswinner(bo,le):
    return ((bo[1]==le and bo[5]==le and bo[9]==le) or
            (bo[7]==le and bo[5]==le and bo[3]==le) or
            (bo[7]==le and bo[8]==le and bo[9]==le) or
            (bo[4]==le and bo[5]==le and bo[6]==le) or
            (bo[1]==le and bo[2]==le and bo[3]==le) or
            (bo[7]==le and bo[4]==le and bo[1]==le) or
            (bo[8]==le and bo[5]==le and bo[2]==le) or
            (bo[9]==le and bo[6]==le and bo[3]==le))

def getboardcopy(board):
    dupeboard = []
    for i in board:
        dupeboard.append(i)
    return dupeboard

def isspacefree(board,move):
    return board[move] == ' '

def getplayermove(board):
    move = ' '
    while move not in '1 2 3 4 5 6 7 8 9'.split() or not isspacefree(board,int(move)):
        print("обери вільне поле для заповнення від 1 до 9")
        move = input().strip()
    return int(move)

def chooserandommovefromlist(board,movelist):
    possiblemoves = []
    for i in movelist:
        if isspacefree(board,i):
            possiblemoves.append(i)
    if len(possiblemoves) != 0:
        return random.choice(possiblemoves)
    else:
        return None

#ai computer

def getcomputermovehard(board, computerletter):
    if computerletter == 'X':
        playerletter = 'O'
    else:
        playerletter = 'X'
    # виграти компу
    for i in range (1,10):
        copy = getboardcopy(board)
        if isspacefree(copy,i):
            makemove(copy,computerletter,i)
            if iswinner(copy,computerletter):
                return i    
    #не дати виграти гравцю
    for i in range (1,10):
        copy = getboardcopy(board)
        if isspacefree(copy,i):
            makemove(copy,playerletter,i)
            if iswinner(copy,playerletter):
                return i   
    #заняти центр
    if isspacefree(board,5):
        return 5
    #заняти кути
    move = chooserandommovefromlist(board, [1,3,7,9])
    if move != None:
        return move
    #заняти сторони
    return chooserandommovefromlist(board,[2,4,6,8])

def getcomputermovenorm(board, computerletter):
    # виграти компу
    for i in range (1,10):
        copy = getboardcopy(board)
        if isspacefree(copy,i):
            makemove(copy,computerletter,i)
            if iswinner(copy,computerletter):
                return i    
    #заняти центр
    if isspacefree(board,5):
        return 5
    #заняти кути
    move = chooserandommovefromlist(board, [1,3,7,9])
    if move != None:
        return move
    #заняти сторони
    return chooserandommovefromlist(board,[2,4,6,8])

def getcomputermoveisi(board, computerletter):
    # виграти компу
    for i in range (1,10):
        copy = getboardcopy(board)
        if isspacefree(copy,i):
            makemove(copy,computerletter,i)
            if iswinner(copy,computerletter):
                return i    
    return chooserandommovefromlist(board, range(1,10))

def isboardfull(board):
    for i in range(1,10):
        if isspacefree(board,i):
            return False
    return True

def computercomplexity(complexity):
    while True:
        complexity = input("выбери сложность 1=изи 2=норм 3=хард").lower().strip()
        if complexity in ['1','изи','isi','2','норм','norm','3','хард','hard']:
            return complexity
        print("не коректыный ввод")

print("вітання в гру кальмара на мінімалках")

while True:
    theboard = [' ']*10
    complexity = ''
    complexity = computercomplexity(complexity)
    if complexity in ['1','изи','isi']:
        getcomputermove = getcomputermoveisi
    elif complexity in ['2','норм','norm']:
        getcomputermove = getcomputermovenorm
    else:
        getcomputermove = getcomputermovehard

    playerletter, computerletter = inputplyerletter()
    turn = whogofirst()
    print("рандом сказав, що перший ходить - ", turn)
    while True:
        if turn == 'player':
            drawboard(theboard)
            move = getplayermove(theboard)
            makemove(theboard, playerletter, move)

            if iswinner(theboard, playerletter):
                drawboard(theboard)
                print("ти обіграв АІ")
                break
            else:
                if isboardfull(theboard):
                    drawboard(theboard)
                    print("нічія, поля закінчились")
                    break
                else:
                    turn = 'computer'

        else: 
            move = getcomputermove(theboard,computerletter)
            makemove (theboard, computerletter,move)
            if iswinner(theboard,computerletter):
                drawboard(theboard)
                print("комп виграв, що ти плакі плакі")
                break
            else:
                if isboardfull(theboard):
                    drawboard(theboard)
                    print("нічія")
                    break
                else:
                    turn = 'player'
    if not playagain():
        break
