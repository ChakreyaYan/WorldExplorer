/** Shortcut for GeoJSON.FeatureCollection<GeoJSON.GeometryObject> */
export type FeatureCollection = GeoJSON.FeatureCollection<GeoJSON.GeometryObject>;

/**
 * Tile naming scheme follows TMS convention.
 *
 * @export
 * @interface ITile
 */
export interface ITile {
  x: string;
  y: string;
  zoom: string;
  layers: string[];
}

export interface ITileService {
  getTile(tile: ITile, cb: ( error: Error, collection: { [key: string]: GeoJSON.FeatureCollection<GeoJSON.GeometryObject> }) => void);
}
