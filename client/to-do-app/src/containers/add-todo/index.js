"use client"
import Input from '@/components/input'
import Button from '@/components/button'
import React, { useState } from 'react'
import Flex from '@/components/flex'
import { addTodo } from '@/services/todos'
import { useRouter } from 'next/navigation'

const AddTodoContainer = () => {
    const [content, setContent] = useState('');
    const router = useRouter();

    const handleButtonClick = async () => {
        const res = await addTodo(content);
        console.log(res);

        router.refresh();
    }

    return (
        <Flex justify='center' mt={5}>
            <Input value={content} onChange={e => setContent(e.target.value)} width='30%' placeholder='Description' />
            <Button width='5%' onClick={handleButtonClick}>Add</Button>
        </Flex>
    )
}

export default AddTodoContainer