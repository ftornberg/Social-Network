import { useMutation, useQuery, useQueryClient } from 'react-query';
import Moment from 'react-moment';
import { useParams } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';
import Message from './Message';

const UserWall = () => {
	const queryClient = useQueryClient();
	const { userId } = useParams<{ userId: string }>();

	const { isLoading, error, data } = useQuery({
		queryKey: ['UserWallData'],
		queryFn: () => {
			return agent.ApplicationPost.getAllPostsToUser(
				parseInt(userId as string)
			).then((response) => response);
		},
	});

	const addPostMutation = useMutation({
		mutationFn: () => {
			return agent.ApplicationFollower.follow({
				followerUserId: 1,
				followerUserName: '',
				followsUserId: parseInt(userId as string),
				followsUserName: '',
			});
		},

		onSuccess: () => {
			queryClient.invalidateQueries(['UserFollowsData, UserFollowerData']);
		},
	});

	if (isLoading)
		return (
			<>
				<Loading />
			</>
		);

	if (error)
		return (
			<div className="row rounded">
				<div className="col-sm bg-light text-dark p-4 mb-4 rounded">
					An error has occurred. Please try again later.
				</div>
			</div>
		);

	return (
		<>
			<div className="container-sm">
				<Message />
				<div className="row bg-light text-dark rounded">
					<div className="col-sm rounded">
						<div className="float-left p-4">
							<h3 className="display-3">Feed</h3>
						</div>
						<div className="float-right p-4">
							<button type="button" className="btn btn-primary m-4">
								Meddelanden:{' '}
								<span className="badge badge-light">{data?.length}</span>
							</button>
							<button
								onClick={() => addPostMutation.mutate()}
								type="button"
								className="btn btn-success m-4"
							>
								Follow
							</button>
						</div>
						<div className="clearfix"></div>
						<ul className="list-unstyled  p-3 mb-2">
							{data &&
								data.map((post) => (
									<li
										className="media bg-white text-dark p-4 mb-4 border rounded"
										key={post.id}
									>
										<img
											className="mr-3 pe-4 rounded-circle"
											src={`https://i.pravatar.cc/75?=${post.postedByUserId}`}
											alt="{post.postedByUserId}"
										/>
										<div className="fs-4">{post.postedByUserName}</div>

										<div className="media-body">
											<p className="mt-0 mb-1 lead">{post.postedMessage}</p>
											<samp>
												<Moment format="DD/MM/YY HH:mm">
													{post.postedTime}
												</Moment>
											</samp>
										</div>
									</li>
								))}
						</ul>
					</div>
				</div>
			</div>
		</>
	);
};

export default UserWall;
