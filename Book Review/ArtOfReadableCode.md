# The Art of Readable Code: 
## Chapter 4: Aesthetics
---
## Introduction
- The aesthetics of code focuses on how the code appears on the screen.
- Programmers spend more time **looking at code** than **writing code**.
- Therefore, it is necessary that the programmer reading the code doesn't get frustrated or confused because of how the code looks.
- Good source code should be "easy on the eyes", like a well-designed magazine.

### Principles

There are 3 main principles of good aesthetics in code:
1. Consistent layout with patterns the reader can get used to.
2. Make similar code look similar
3. Group related lines of code into blocks
---
## Common Practices

### 1. Rearrange Line Breaks to Be Consistent and Compact

### 2. Use Methods to Clean Up Irregularity

### 3. Use Column Alignment When Helpful

### 4. Pick a Meaningful Order, and Use It Consistently

### 5. Organize Declarations into Blocks

### 6. Break Code into “Paragraphs”
---
## Personal Style versus Consistency
There are some aesthetic choices that just boil down to personal style. 
For example, placement of braces:
```
class Logger {
 ...
};
```
or 
```
class Logger 
{
 ...
};
```
Either style may be used, and is dependent on the personal style of the developer.
Choosing one over the other does not affect the readability of the code, but if both are used in a mixed manner, it leads to bad aesthetics due to inconsistent patterns
> #### KEY IDEA:
> consistent style is more important than the "right" style.
---
## Conclusion
In short, through the chapter we learnt: 
- An aesthetically good code helps readers understand the code faster.
- The following techniques are used to make the code look aesthetically pleasing:
    1. If multiple blocks of code are doing similar things, try to give them the same silhouette.
    2. Aligning parts of the code into “columns” can make code easy to skim through.
    3. If code mentions A, B, and C in one place, don’t say B, C, and A in another. Pick a
       meaningful order and stick with it.
    4. Use empty lines to break apart large blocks into logical “paragraphs.”
---
## Authors
- *Sai Harshit B*
- *Prajwal HM*