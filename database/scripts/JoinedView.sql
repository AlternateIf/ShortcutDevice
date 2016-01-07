CREATE VIEW `PresetWithButtons` AS
    SELECT 
        p.id AS presetId,
        p.name AS presetName,
        p.color AS presetColor,
        b.id AS buttonId,
        b.assignment AS buttonAssignment,
        b.name AS buttonName
    FROM
        shortcutdevice.Preset p
            INNER JOIN
        shortcutdevice.Preset_has_Button pb ON (p.id = pb.Preset_id)
            INNER JOIN
        shortcutdevice.Button b ON (pb.Button_id = b.id);
