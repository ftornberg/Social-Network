import { useQuery, useQueryClient } from 'react-query';
import Moment from 'react-moment';
import agent from '../actions/agent';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { DirectMessage } from '../models/directmessage';

interface props {
	chatId: number;
}
const ShowMessages = ({ chatId }: props) => {
	const [values, setValues] = useState<DirectMessage[]>();

	const queryClient = useQueryClient();

	useEffect(() => {
		return () => {
			agent.ApplicationDirectMessage.list(1, chatId).then((response) =>
				setValues(response)
			);
			queryClient.invalidateQueries(['showMessageData']);
		};
	}, [chatId]);

	return (
		<div className="container-fluid">
			<div className="col-sm rounded">
				<div className="clearfix"></div>
				<h3 className="display-2 ps-3">ShowMessages</h3>
				<ul className="list-unstyled p-3 mb-2">
					{values &&
						values.map((messages, index: number) => (
							<li
								className="media bg-white text-dark p-4 mb-4 border rounded shadow-lg"
								key={index}
							>
								<Link
									to={`/user/${messages.senderUserId}`}
									className="text-decoration-none"
								>
									<img
										className="mr-3 pe-4 rounded-circle"
										src={`https://i.pravatar.cc/75?=${messages.senderUserId}`}
										alt={messages.senderUserName}
									/>
									<div className="fs-4 d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none">
										{messages.senderUserName}
									</div>
								</Link>
								<div className="media-body">
									<p className="mt-0 mb-1 lead">{messages.message}</p>
									<samp>
										<Moment format="DD/MM/YY HH:mm">{messages.timeSent}</Moment>
									</samp>
								</div>
							</li>
						))}
				</ul>
			</div>
		</div>
	);
};

export default ShowMessages;
