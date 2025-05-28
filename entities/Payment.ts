import { Entity, PrimaryGeneratedColumn, Column, ManyToOne } from "typeorm";
import { User } from "./User";
import { Ticket } from "./Ticket";

@Entity()
export class Payment {
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    amount: number;

    @Column()
    paymentDate: Date;

    @Column()
    status: string;

    @ManyToOne(() => User, (user) => user.id)
    user: User;

    @ManyToOne(() => Ticket, (ticket) => ticket.id)
    ticket: Ticket;
}
