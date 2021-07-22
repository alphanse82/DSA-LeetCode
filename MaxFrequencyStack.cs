public class CustomStack {

    int maxFrequencyCount = 0; 
    
    Dictionary<int,int> frequencyCounter = new Dictionary<int,int>();
    Dictionary<int,Stack<int>> stack = new Dictionary<int,Stack<int>>();
    
    public FreqStack() {
        maxFrequencyCount = 1;
        frequencyCounter = new Dictionary<int,int>();
        stack = new Dictionary<int,Stack<int>>();
    }
    
    public void Push(int val) {
        
        int currentItemFrequency = 0;
        
        if( !frequencyCounter.ContainsKey(val) ) {
            frequencyCounter.Add(val, currentItemFrequency);
        }
        frequencyCounter[val] = frequencyCounter[val] + 1;
        currentItemFrequency = frequencyCounter[val];
        
        
        if( currentItemFrequency > maxFrequencyCount  )
            maxFrequencyCount = currentItemFrequency;
        
        if( !stack.ContainsKey(currentItemFrequency) )
            stack.Add(currentItemFrequency, new Stack<int>());

        stack[currentItemFrequency].Push(val);
    }
    
    public int Pop() {
        
        int item = stack[maxFrequencyCount].Pop();   
        frequencyCounter[item] -= 1;    
        
        if( frequencyCounter[item] == 0)
            frequencyCounter.Remove(item);
        
        if( stack[maxFrequencyCount].Count == 0 )
            stack.Remove(maxFrequencyCount--);
   
        return item;     
    }
}
