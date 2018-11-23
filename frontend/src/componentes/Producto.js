import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import PropTypes from 'prop-types';

import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import FormControl from '@material-ui/core/FormControl';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import Select from '@material-ui/core/Select';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import IconButton from '@material-ui/core/IconButton';
import StarBorderIcon from '@material-ui/icons/StarBorder';
import axios from 'axios';

import Menu from '../layout/Menu';

const config = {
	headers: {
	  'Content-Type': 'application/json',
	  'Accept': 'application/json'
	}
}

const styles = theme => ({
	container: {
	  display: 'flex',
	  flexWrap: 'wrap',
	},
	textField: {
	  marginLeft: theme.spacing.unit,
	  marginRight: theme.spacing.unit,
	  /*width: 200,*/
	},
	menu: {
	  width: 200,
	},
	button: {
		width: 200,
		margin: theme.spacing.unit,
	},
	  input: {
		display: 'none',
	},
	selectEmpty: {
		marginTop: theme.spacing.unit * 2,
	  },
	gridList: {
		flexWrap: 'nowrap',
		// Promote the list into his own layer on Chrome. This cost memory but helps keeping high FPS.
		transform: 'translateZ(0)',
	},
	title: {
		color: theme.palette.primary.light,
	},
	titleBar: {
		background:
			'linear-gradient(to top, rgba(0,0,0,0.7) 0%, rgba(0,0,0,0.3) 70%, rgba(0,0,0,0) 100%)',
	},
});

class Producto extends Component {

	constructor(props) {
		super(props);
		this.state = {
			id:'',
			codproducto:'',
			nombreproducto:'',
			tipoproducto:'',
			saldominimo:'',
			estado:'',
			nombreproductocomponente:'Ingreso Producto',
		};
	}

	handleClickCrear = () => {

		if( this.state.id !== '' && 
			this.state.codproducto !== '' &&
			this.state.nombreproducto !== '' &&
			this.state.tipoproducto !== '' &&
			this.state.saldominimo !== '' &&
			this.state.estado !== ''){

			axios.post('http://localhost:50948/api/v1/producto', {
				'id': this.state.id,
				'codproducto': this.state.codproducto,
				'nombreproducto': this.state.nombreproducto,
				'tipoproducto': this.state.tipoproducto,
				'saldominimo': this.state.saldominimo,
				'estado': this.state.estado
			}, config)
				.then((result) => {
					if (result.status === 200){
							alert(result.data.mensaje);
							//window.location.href = "/app/Producto";    
					}else{
						alert(result.data.mensaje);
					}
			})
			.catch((err) => {
				alert(err);
			})
		}else{
			alert('Debe llenar los campos');
		}
	}

	handleClickLeer = () => {
		if( this.state.codproducto !== '' ){

			axios.get('http://localhost:5000/api/v1/producto/'+this.state.codproducto, {
            }, config)
				.then((result) => {
					console.log(result);
					if (result.status === 200){
						this.setState({
							id:result.data.id, nombreproducto:result.data.nombreproducto
							, tipoproducto:result.data.tipoproducto, saldominimo:result.data.saldominimo
							, estado:result.data.estado
						});
						//alert(result.data.nombreproducto);
						//window.location.href = "/app/Producto";    
					}else{
						alert(result.data.mensaje);
					}
			})
			.catch((err) => {
				alert(err);
			})
		}else{
			alert('Debe llenar campo codigo');
		}
	}

	handleClickActualizar = () => {
		if( 
		this.state.id !== '' && 
		this.state.codproducto !== '' &&
		this.state.nombreproducto !== '' &&
		this.state.tipoproducto !== '' &&
		this.state.saldominimo !== '' &&
		this.state.estado !== ''){

		axios.post('http://localhost:4000/api/Productodb/update', {
			'id': this.state.id,
			'codproducto': this.state.codproducto,
			'nombreproducto': this.state.nombreproducto,
			'tipoproducto': this.state.tipoproducto,
			'saldominimo': this.state.saldominimo,
			'estado': this.state.estado
		}, config)
			.then((result) => {
				if (result.status === 200){
						alert(result.data.mensaje);
						//window.location.href = "/app/Producto";    
				}else{
					alert(result.data.mensaje);
				}
		})
		.catch((err) => {
			alert(err);
		})
	}else{
		alert('Debe llenar los campos');
	}
}

	handleClickEliminar = () => {
		if( 
			this.state.id !== ''){
	
			axios.post('http://localhost:4000/api/Productodb/delete', {
				'id': this.state.id
			}, config)
				.then((result) => {
					if (result.status === 200){
							alert(result.data.mensaje);
							//window.location.href = "/app/Producto";    
					}else{
						alert(result.data.mensaje);
					}
			})
			.catch((err) => {
				alert(err);
			})
		}else{
			alert('Debe llenar los campos');
		}
	}

	handleChange = event => {
		this.setState({ [event.target.name]: event.target.value });
	};

	componentDidMount() {
		this.setState({
		  labelWidth: ReactDOM.findDOMNode(this.InputLabelRef).offsetWidth,
		});
	  };

	render () {
		const { classes } = this.props;
		return (
			<div>
				<Menu/>
				<br/>
				<div className={classes.root}>
					<GridList className={classes.gridList} cols={2.5}>
					</GridList>
				</div>
				<br/>
				<TextField
					id="Id"
					label="Id"
					className={classes.textField}
					autoComplete="current-password"
					margin="normal"
					value={this.state.id}
					onChange={e => this.setState({ id: e.target.value })}
					variant="outlined"
				/>				
				<TextField
					id="codproducto"
					label="C&oacute;digo Producto"
					className={classes.textField}
					autoComplete="current-password"
					margin="normal"
					value={this.state.codproducto}
					onChange={e => this.setState({ codproducto: e.target.value })}
					variant="outlined"
				/>
				<TextField
					id="nombreproducto"
					label="Nombre Producto"
					className={classes.textField}
					autoComplete="current-password"
					margin="normal"
					value={this.state.nombreproducto}
					onChange={e => this.setState({ nombreproducto: e.target.value })}
					variant="outlined"
				/>
				<br/>
				<TextField
					id="tipoproducto"
					label="Tipo Producto"
					className={classes.textField}
					autoComplete="current-password"
					margin="normal"
					value={this.state.tipoproducto}
					onChange={e => this.setState({ tipoproducto: e.target.value })}
					variant="outlined"
				/>
				<TextField
					id="saldominimo"
					label="Saldo Minimo"
					className={classes.textField}
					autoComplete="current-password"
					margin="normal"
					value={this.state.saldominimo}
					onChange={e => this.setState({ saldominimo: e.target.value })}
					variant="outlined"
				/>
				<FormControl variant="outlined" className={classes.formControl}>
					<InputLabel
						ref={ref => {
							this.InputLabelRef = ref;
						}}
						htmlFor="outlined-estado-simple"
						>
						Estado
					</InputLabel>
					<Select
					value={this.state.estado}
					onChange={this.handleChange}
					input={
						<OutlinedInput
						labelWidth={this.state.labelWidth}
						name="estado"
						id="outlined-estado-simple"
						/>
					}
					>
					<MenuItem value="">
						<em>None</em>
					</MenuItem>
					<MenuItem value={1}>Activo</MenuItem>
					<MenuItem value={0}>Inactivo</MenuItem>
					</Select>
				</FormControl>
				<br/>
				<Button  
					variant="contained"
					color="primary"
					className={classes.button}
					onClick={this.handleClickCrear}
				>
				Crear
				</Button >
				<br/>
				<Button  
					variant="contained"
					color="primary"
					className={classes.button}
					onClick={this.handleClickLeer}
				>
				Leer
				</Button >
				<br/>
				<Button  
					variant="contained"
					color="primary"
					className={classes.button}
					onClick={this.handleClickActualizar}
				>
				Actualizar
				</Button >
				<br/>
				<Button  
					variant="contained"
					color="primary"
					className={classes.button}
					onClick={this.handleClickEliminar}
				>
				Eliminar
				</Button >
			</div>
		);
	}
}

Producto.propTypes = {
	classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Producto);