import { NgModule } from '@angular/core'; // NgModule é um módulo do Angular que define um módulo da aplicação
import { RouterModule, Routes } from '@angular/router'; // RouterModule e Routes são módulos do Angular que definem as rotas da aplicação
import { HomeComponent } from './home/home.component';
import { CatalogComponent } from './catalog/catalog.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';

// Define as rotas da aplicação
const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Define a rota padrão da aplicação
  { path: 'home', component: HomeComponent, title: 'Home - Joe\'s Robot Shop' }, // Define a rota para a página inicial da aplicação
  { path: 'catalogo/:filtro', component: CatalogComponent, title: 'Catalog - Joe\'s Robot Shop' }, // Define a rota para a página de catálogo de produtos
  { path: 'carrinho', component: CarrinhoComponent, title: 'Carrinho - Joe\'s Robot Shop' } // Define a rota para a página de carrinho de compras
];

// Módulo que define as rotas da aplicação
@NgModule({
  declarations: [], // Declarações do módulo. Componentes, diretivas e pipes que pertencem ao módulo
  imports: [
    RouterModule.forRoot(routes) // Importa o módulo de rotas da aplicação
  ],
  exports: [
    RouterModule // Exporta o módulo de rotas da aplicação
  ]
})
export class AppRoutingModule { }
