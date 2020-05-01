import os
import bpy

full_path = os.path.realpath(__file__)
path = os.path.dirname(full_path)

bpy.ops.object.delete(use_global=False)
# Load the svg image
bpy.ops.import_curve.svg(filepath=path + "/layout.svg")

# Select the object
bpy.ops.object.select_pattern(pattern="Curve")
bpy.context.view_layer.objects.active = bpy.data.objects['Curve']

# Convert to mesh
bpy.ops.object.convert(target='MESH')

# Add Z dimension
bpy.ops.object.editmode_toggle()
bpy.ops.mesh.select_all(action='SELECT')
bpy.ops.mesh.extrude_region_move(MESH_OT_extrude_region={"use_normal_flip":False, "mirror":False}, TRANSFORM_OT_translate={"value":(0, 0, 0.0492128), "orient_type":'NORMAL', "orient_matrix":((-0.879582, 0.475747, 0), (-0.475747, -0.879582, 0), (0, 0, 1)), "orient_matrix_type":'NORMAL', "constraint_axis":(False, False, True), "mirror":False, "use_proportional_edit":False, "proportional_edit_falloff":'SMOOTH', "proportional_size":1, "use_proportional_connected":False, "use_proportional_projected":False, "snap":False, "snap_target":'CLOSEST', "snap_point":(0, 0, 0), "snap_align":False, "snap_normal":(0, 0, 0), "gpencil_strokes":False, "cursor_transform":False, "texture_space":False, "remove_on_cancel":False, "release_confirm":False, "use_accurate":False})
bpy.ops.object.editmode_toggle()

# Change Z dimension
# bpy.data.objects['Curve'].dimensions[2] = 0.05

# Center the origin of the object
bpy.ops.object.origin_set(type='ORIGIN_GEOMETRY', center='MEDIAN')
bpy.context.object.location[0] = 0
bpy.context.object.location[1] = 0

# Add ground plane
bpy.ops.mesh.primitive_plane_add(size=2, enter_editmode=False, location=(0, 0, 0))
bpy.context.object.scale[0] = 0.25
bpy.context.object.scale[1] = 0.25

# Save the model
bpy.ops.export_mesh.stl(filepath=path + "/model.stl")

