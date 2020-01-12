
import { isArray } from './index'
var replaceNative = function(array, index, removeCount, insert) {
  if (insert && insert.length) {
      // Inserting at index zero with no removing: use unshift
      if (index === 0 && !removeCount) {
          array.unshift.apply(array, insert)
      }
      // Inserting/replacing in middle of array
      else if (index < array.length) {
          array.splice.apply(array, [index, removeCount].concat(insert))
      }
      // Appending to array
      else {
          array.push.apply(array, insert)
      }
  }
  else {
      array.splice(index, removeCount)
  }

  return array
}
export default {
  removeAt(array, index) {
    if(!isArray(array)) return array
    var len = array.length
    if (index >= 0 && index < len) {
      array.splice(index, 1)
    }

    return array
  },
  /**
   * Inserts items in to an array.
   *
   * @param {Array} array The Array in which to insert.
   * @param {Number} index The index in the array at which to operate.
   * @param {Array} items The array of items to insert at index.
   * @return {Array} The array passed.
   */
  insert: function(array, index, items) {
    return replaceNative(array, index, 0, items)
  }
}
