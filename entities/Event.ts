import { Entity, PrimaryGeneratedColumn, Column, OneToMany } from "typeorm";
import { Ticket } from "./Ticket";

@Entity()
export class Event {
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    title: string;

    @Column()
    description: string;

    @Column()
    date: Date;

    @Column()
    price: number;

    @OneToMany(() => Ticket, (ticket) => ticket.event)
    tickets: Ticket[];
}
