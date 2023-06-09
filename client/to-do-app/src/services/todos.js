const BASE_URL = "http://localhost:5083/api/todos";

export async function fetchTodos() {
    try {
        const res = await fetch(`${BASE_URL}`, {
            cache: 'no-store',
            // next: { 
            //     revalidate: 10,
                 
            // }
        });
        return res.json();
    } catch (error) {
        console.log(error);
        throw new Error("Error happened while fetching todos", error);
    }
}

export async function fetchTodo(id) {
    try {
        const res = await fetch(`${BASE_URL}/${id}`, {
            cache: 'no-store',
        });
        
        return res.json();
    } catch (error) {
        console.log(error);
        throw new Error("Error happened while fetching todo", error);
    }
}

export async function updateTodo(id, content) {
    try {
        const res = await fetch(`${BASE_URL}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                content: content
            })
        });
        return res.ok;
    } catch (error) {
        console.log(error);
        throw new Error("Error happened while updating todo", error);
    }
}

export const addTodo = async (content) => {
    try {
        const res = await fetch(`${BASE_URL}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                content: content
            })
        });
        return res.json();
    }
    catch (error) {
        console.log(error);
        throw new Error("Error happened while posting data", error);
    }
}