"use client"
import Button from '@/components/button'
import Card from '@/components/card';
import CardHeader from '@/components/card-header';
import CardBody from '@/components/card-body';
import CardFooter from '@/components/card-footer';
import Heading from '@/components/heading';
import Text from '@/components/text';
import React, { useState } from 'react'
import Modal from '@/components/modal'
import ModalOverlay from '@/components/modal-overlay'
import ModalCloseButton from '@/components/modal-close-button'
import ModalBody from '@/components/modal-body'
import ModalContent from '@/components/modal-content'
import ModalFooter from '@/components/modal-footer'
import ModalHeader from '@/components/modal-header'
import Input from '@/components/input'
import { updateTodo } from '@/services/todos';
import { useRouter } from 'next/navigation';

const TodoItem = ({ todo }) => {

    const router = useRouter();

    const [isEditModalOpen, setIsEditModalOpen] = useState(false);
    const [editContent, setEditContent] = useState(todo.content);

    const handleEditClick = (e) => {
        setIsEditModalOpen(!isEditModalOpen);
    }

    const onClose = () => {
        setIsEditModalOpen(false);
    }

    const update = async () => {
        const res = await updateTodo(todo.id, editContent);

        if(res) {
            router.refresh();
            setIsEditModalOpen(false);
        }
    }

    return (
        <div>
            <Card key={todo.id}>
                <CardBody>
                    <Text>{todo.content}</Text>
                </CardBody>
                <CardFooter>
                    <Button onClick={handleEditClick}>Edit</Button>
                </CardFooter>
            </Card>
            <Modal isOpen={isEditModalOpen} onClose={onClose}>
                <ModalOverlay />
                <ModalContent>
                    <ModalHeader>Edit Todo</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        <Input value={editContent} onChange={(e) => setEditContent(e.target.value)} />
                    </ModalBody>
                    <ModalFooter>
                        <Button colorScheme='blue' mr={3} onClick={update} >
                            Save
                        </Button>
                        <Button variant='ghost' onClick={onClose}>Cancel</Button>
                    </ModalFooter>
                </ModalContent>
            </Modal>
            {/* //TODO:  */}
            {/* <TodoItemEdit todo={todo} isOpen={isEditModalOpen} setIsOpen={setIsEditModalOpen}/> */}
        </div>

    )
}

export default TodoItem