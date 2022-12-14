import { ChangeEvent, useEffect, useState } from 'react';
import agent from '../actions/agent';
import { useMutation, useQueryClient } from 'react-query';
import { useParams } from 'react-router-dom';

const Message = () => {
	const queryClient = useQueryClient();
	const [textAreaValue, settextAreaValue] = useState('');
	const [user, setUser] = useState<any>([]);
	const { userId } = useParams<{ userId: string }>();

	useEffect(() => {
		agent.ApplicationUser.getUser(parseInt(userId as string)).then(
			(response) => {
				setUser(response);
			}
		);
	}, []);

	const handleInputChange = (event: ChangeEvent<HTMLTextAreaElement>) => {
		settextAreaValue(event.target.value);
	};

	const addPostMutation = useMutation({
		mutationFn: () => {
			return agent.ApplicationPost.createPost({
				postedMessage: textAreaValue,
				postedByUserId: 1,
				postedByUserName: '',
				postedToUserId: parseInt(userId as string),
			});
		},
		onSuccess: () => {
			queryClient.invalidateQueries(['UserWallData']);
			settextAreaValue('');
		},
	});

	return (
		<>
			<div className="row rounded">
				<div className="col-sm bg-light text-dark p-4 mb-4 rounded">
					<h2 className="display-2">Meddelande till {user.name}</h2>

					<div className="form-group ">
						<label>Lämna ett meddelande:</label>
						<textarea
							className="form-control form-control-lg"
							id="message"
							name="message"
							onChange={handleInputChange}
							value={textAreaValue}
						></textarea>
					</div>
					<button
						type="submit"
						className="btn btn-primary "
						onClick={() => addPostMutation.mutate()}
					>
						Send
					</button>
				</div>
			</div>
		</>
	);
};

export default Message;
